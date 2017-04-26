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
                    } else if(res.status == 2) {
                        alert("Thêm sản phẩm không thành công. Mã nhóm sản phẩm đã tồn tại.")
                    } else {
                        alert("Thêm sản phẩm không thành công. Meta tittle sản phẩm đã tồn tại.")
                    }
                }
            })
        });
    }
}

create.init();