$(function () {
    var l = abp.localization.getResource('CourseManager_Ver02');

    var createModal = new abp.ModalManager(abp.appPath + 'Classrooms/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Classrooms/EditModal');


    var dataTable = $('#ClassroomTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(courseManager_Ver02.classrooms.classroom.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('CourseManager_Ver02.Classrooms.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('CourseManager_Ver02.Classrooms.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'ClassroomDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        courseManager_Ver02.classrooms.classroom.delete(data.record.id)
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
                    title: l('Course'),
                    data: "courseName"
                },
                {
                    title: l('Students'),
                    data: "studentName"
                },
                {
                    title: l('Students'),
                    data: "studentName"
                },
                {
                    title: l('DateStart'),
                    data: "dateStart"
                },
                {
                    title: l('DateEnd'),
                    data: "dateEnd"
                },
                {
                    title: l('SessionsStart'),
                    data: "sessionStart"
                },
                {
                    title: l('SessionsEnd'),
                    data: "sessionEnd"
                },
                {
                    title: l('SessionsEachWeek'),
                    data: "sessionsEachWeek"
                }
            ]
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'Classrooms/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewClassroomButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});

$(".js-select2").select2({
    closeOnSelect: false,
    placeholder: "Placeholder",
    allowHtml: true,
    allowClear: true,
    tags: true,
    templateSelection: function (data, container) {
        $(data.element).attr('data-custom-attribute', data.customValue);
        return data.text;
    }
});
$('.js-select2').find(':selected').data('custom-attribute');