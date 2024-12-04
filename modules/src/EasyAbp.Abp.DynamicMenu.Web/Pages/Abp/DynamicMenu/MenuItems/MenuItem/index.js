$(function () {

    var l = abp.localization.getResource('EasyAbpAbpDynamicMenu');

    var service = easyAbp.abp.dynamicMenu.menuItems.menuItem;
    var createModal = new abp.ModalManager(abp.appPath + 'Abp/DynamicMenu/MenuItems/MenuItem/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Abp/DynamicMenu/MenuItems/MenuItem/EditModal');

    var dataTable = $('#MenuItemTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList, function() {
            return { parentId: parentId };
        }),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('EasyAbp.Abp.DynamicMenu.MenuItem.Update'),
                                action: function (data) {
                                    editModal.open({
                                        id: data.record.id
                                    });
                                }
                            },
                            {
                                text: l('SubMenuItems'),
                                action: function (data) {
                                    document.location.href = document.location.origin + abp.appPath +  "Abp/DynamicMenu/MenuItems/MenuItem?parentId=" + data.record.id;
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('EasyAbp.Abp.DynamicMenu.MenuItem.Delete'),
                                confirmMessage: function (data) {
                                    return l('MenuItemDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete({
                                            id: data.record.id
                                        })
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('MenuItemId'),
                data: "id"
            },
            {
                title: l('MenuItemDisplayName'),
                data: "displayName"
            },
            {
                title: l('MenuItemOrder'),
                data: "order"
            },
            {
                title: l('MenuItemIsDisabled'),
                data: "isDisabled"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewMenuItemButton').click(function (e) {
        e.preventDefault();
        createModal.open({ parentId: parentId });
    });
});
