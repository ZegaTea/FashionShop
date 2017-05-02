var deleteAdmin = {
    init: function () {
        deleteAdmin.events();
    },

    events: function () {
        var Domain = 'http://' + location.hostname + ':' + location.port;
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: {
                    maSanPham: $(this).data('id')
                },
                url: Domain + '/Admin/Product/DeleteProduct',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Xóa sản phẩm thành công");
                        window.location.href = "/Admin/Product/Index"
                    }
                }
            })
        });

        $('.btn-delete-groupPr').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Admin/Group/DeleteGroupPr',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == 1) {
                        alert("Xóa nhóm sản phẩm thành công");
                        window.location.href = "/Admin/Group/Index"
                    }
                    else {
                        alert("Xóa nhóm sản phẩm không thành công")
                    }
                }
            })
        });
        $('.btnDeleteGroupDetail').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Admin/GroupDetail/DeleteGroupDetail',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Xóa loại sản phẩm thành công");
                        window.location.href = "/Admin/GroupDetail/Index"
                    }
                }
            })
        })
    }
}

deleteAdmin.init();
