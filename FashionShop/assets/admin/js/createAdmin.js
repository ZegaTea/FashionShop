var create = {
    init: function () {
        create.events();
    },

    events: function () {
        $('#maloai').off('change').on('change', function () {
            var html = '';
            var ma = $('#maloai').val();
            $.ajax({
                url: '/Admin/Product/loadChiTiet',
                type: 'POST',
                data: id = ma,
                dataType: 'json',
                success: function (res) {
                    if (res.data == "quan") {
                        html += '<label class="control-label col-sm-3" for="28">Size 28 </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="28" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="29">Size 29 </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="29" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="30">Size 30 </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="30" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="31">Size 31 </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="31" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="32">Size 32 </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="32" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="33">Size 33 </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="33" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="34">Size 34 </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="34" value="0" /><br /> \
                        </div>';
                    }
                    else {
                        html += '<label class="control-label col-sm-3" for="S">Size S </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="S" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="M">Size M </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="M" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="L">Size L </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="L" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="XL">Size XL </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="XL" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="XXL">Size XXL </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="XXL" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="XXL">Size XXL </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="XXL" value="0" /><br /> \
                        </div> \
                        <label class="control-label col-sm-3" for="XXXL">Size XXXL </label> \
                        <div class="col-sm-9"> \
                            <input type="number" class="form-control" id="XXXL" value="0" /><br /> \
                        </div>';
                    }
                    $('#chitiet').html(html);
                }
            })
        });

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
        });


        $('#btnCreateProduct').off('click').on('click', function () {
            $.ajax({
                data: {
                    pr: {
                        maSanPham: $('#ma').val(),
                        moTa: $('#mota').val(),
                        giaSanPham: $('#price').val(),
                        chatLieu: $('#chatlieu').val(),
                        loaiSanPhamMa: $('#maloai').val(),
                        mauSac: $('#mau').val(),
                        urlAnh: $('#url').val(),
                        tenSanPham: $('#ten').val(),

                    }
                },
                url: '/Admin/Product/CreateProduct',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        alert("Thêm thông tin sản phẩm thành công");
                        window.location.href = "/Admin/Product/Index"
                    } else {
                        alert("Thêm  sản phẩm không thành công. Mã sản phẩm đã tồn tại.")
                    }
                }
            })
        });


        


    },

}

create.init();