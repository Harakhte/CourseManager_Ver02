$(function () {
    var l = abp.localization.getResource('CourseManager_Ver02');

    var createModal = new abp.ModalManager(abp.appPath + 'Teachers/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Teachers/EditModal');


    var dataTable = $('#TeacherTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(courseManager_Ver02.teachers.teacher.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('CourseManager_Ver02.Teachers.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('CourseManager_Ver02.Teachers.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'TeacherDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        courseManager_Ver02.teachers.teacher.delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Birth Date'),
                    data: "birthDate"
                },
                {
                    title: l('Address'),
                    data: "address"
                },
                {
                    title: l('Phone'),
                    data: "phone"
                },
                {
                    title: l('Email'),
                    data: "email"
                }
            ]
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'Teachers/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewTeacherButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
