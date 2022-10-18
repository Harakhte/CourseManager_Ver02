$(function () {
    var l = abp.localization.getResource('CourseManager_Ver02');

    var createModal = new abp.ModalManager(abp.appPath + 'Courses/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Courses/EditModal');


    var dataTable = $('#CourseTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(courseManager_Ver02.courses.course.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('CourseManager_Ver02.Courses.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('CourseManager_Ver02.Courses.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'CourseDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        courseManager_Ver02.courses.course.delete(data.record.id)
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
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('Teachers'),
                    data: "teacherName"
                }
            ]
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'Courses/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCourseButton').click(function (e) {
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