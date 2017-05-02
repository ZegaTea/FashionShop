var create = {
    init: function () {
        create.events();
    },

    events: function () {
        $('#btnCreateGroupPr').off('click').on('click', function () {
            $.ajax({
                data: {
                    maNhom: $('#ma').val(),
                    tenNhom: $('#ten').val(),
                    tittle: $('#tittle').val()
                },
                url: '/Admin/Group/CreateGroupPr',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == 1) {
                        alert("Thêm thông tin nhóm sản phẩm thành công");
                        window.location.href = "/Admin/Group/Index"
                    } else if (res.status == 2) {
                        alert("Thêm nhóm sản phẩm không thành công. Mã nhóm sản phẩm đã tồn tại.")
                    } else {
                        alert("Thêm nhóm sản phẩm không thành công. Meta tittle nhóm sản phẩm đã tồn tại.")
                    }
                }
            })
        });

        $('#btnCreateGroupDetail').off('click').on('click', function () {
            $.ajax({
                data: {
                    maLoai: $('#ma').val(),
                    tenLoai: $('#ten').val(),
                    tittle: $('#tittle').val(),
                    maNhom: $('#manhom').val()
                },
                url: '/Admin/GroupDetail/CreateGroupDetail',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == 1) {
                        alert("Thêm thông tin loại sản phẩm thành công");
                        window.location.href = "/Admin/GroupDetail/Index"
                    } else if (res.status == 2) {
                        alert("Thêm loại sản phẩm không thành công. Mã nhóm sản phẩm đã tồn tại.")
                    } else {
                        alert("Thêm loại sản phẩm không thành công. Meta tittle loại sản phẩm đã tồn tại.")
                    }
                }
            })
        })
    }
}

create.init();