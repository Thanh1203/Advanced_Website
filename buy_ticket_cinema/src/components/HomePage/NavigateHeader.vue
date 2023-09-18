<template>
    <div class="nav_container">
        <div class="nav_icon">
            <img src="../../assets/logo.png" alt="">
        </div>
        <div class="nav_menu">
            <div class="nav_search input-group mb-3">
                <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'magnifying-glass']" size="lg" style="color: #000000;" /></span>
                <input type="text" class="form-control from_search" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1">
            </div>
            <nav>
                <a href="#" class="txt_link">Rạp chiếu phim</a> | 
                <a href="#" class="txt_link">Khuyến mãi</a>
            </nav>
        </div>
        <div class="nav_login_user">
            <button type="button" class="btn btn-outline-dark" :class="{hide : isShow}">Đăng nhập</button>
            <div class="nav_user" :class="{ hide: !isShow }">
                <font-awesome-icon :icon="['fas', 'circle-user']" size="2xl" style="color: #000000;" />
                <div class="nav_user_info"></div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    computed: {
        
    },
    data() {
        return {
            isShow: false,
            searching: ''
        }
    }
}
</script>
<style>
.nav_container{
    position: absolute;
    top: 0;
    height: 100px;
    width: 90%;
    display: flex;
    justify-content: space-around;
    align-items: center;
}

.input-group-text {
    background-color: white !important;
}

.from_search {
    border-left: 0 !important;
}
</style>