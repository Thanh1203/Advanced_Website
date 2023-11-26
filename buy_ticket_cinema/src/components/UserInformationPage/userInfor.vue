<template>
<div>
    <label class="lb_title">Số điện thoại</label>
    <p>0344401340</p>
    <div class="infor_gr">
        <div class="info_items">
            <label class="lb_title">Họ tên</label>
            <p>Nguyễn Đức Thành</p>
        </div>
        <div class="info_items">
            <label class="lb_title">Email</label>
            <p>ducthanh1122003@gmail.com</p>
        </div>
    </div>
    <div class="infor_gr">
        <div class="info_items">
            <label class="lb_title">Giới tính</label>
            <p>Nam</p>
        </div>
        <div class="info_items">
            <label class="lb_title">Ngày sinh</label>
            <p>1/12/2003</p>
        </div>
    </div>
    <div class="infor_gr">
        <div class="info_items">
            <label class="lb_title">Thành phố</label>
            <p>Hải dương</p>
        </div>
        <div class="info_items">
            <label class="lb_title">Địa chỉ</label>
            <p>Kẻ sặt, Bình giang</p>
        </div>
    </div>
</div>
</template>
<script setup>
</script>
<style scoped>
.lb_title {
    font-size: 14px;
    color: #616161;
}

.infor_gr {
    width: 100%;;
    display: flex;
}
.infor_gr .info_items {
    flex-basis: 50%;
}
</style>