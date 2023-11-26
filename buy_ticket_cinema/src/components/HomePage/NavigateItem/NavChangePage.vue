<template>
<div class="nav_change_ctn">
    <div class="nav_change-page">
        <p class="nav_change-txt" @click="goGitShop">SHOP QUÀ TẶNG</p>|
        <p class="nav_change-txt" @click="goMovieShowing">PHIM ĐANG CHIẾU</p>|
        <p class="nav_change-txt" @click="goUpComingMovie">PHIM SẮP CHIẾU</p>|
        <p class="nav_change-txt">KHUYẾN MÃI</p>
    </div>
</div>
</template> 
<script setup>
import router from '@/Router/router';

const goMovieShowing = () => {
    router.push('/Movie%20showing')
}
const goUpComingMovie = () => {
    router.push('/Up%20coming%20movie')
}
const goGitShop = () => {
    router.push('/Git%20Shop')
}

</script>
<style scoped>
.nav_change_ctn {
    position: relative;
    background: url(../../../assets/bg_gnb.gif) repeat-x top center;
    padding: 27px 0 28px 0;
    box-sizing: content-box;
}
.nav_change-page {
    display: flex;
    justify-content: center;
    height: 18px;
}

.nav_change-page .nav_change-txt {
    margin: 0;
    cursor: pointer;
    font-size: 16px;
    padding: 0 20px;
    color: #555;
    font-family: Arial, Helvetica, sans-serif;
}
</style>