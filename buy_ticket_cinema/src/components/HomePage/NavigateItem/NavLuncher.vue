<template>
  <div class="navLuncher">
    <div class="navLuncher_ctn">
      <div class="navLuncher_social">
        <div class="navLuncher_app">
          <span href="#" class="txt_link" target="_blank">
            <img src="../../../assets/icon_lottecinemaapp.png" />
            Lotte Cinema APP
          </span>
          <div class="navLuncher_app-qr" ref="qrImg">
            <img src="../../../assets/img_appQRcode.jpg" />
          </div>
        </div>
        <div class="navLuncher_fb">
          <a
            href="https://www.facebook.com/LotteCinema"
            class="txt_link"
            target="_blank"
          >
            <img src="../../../assets/icon_fb_top.png" />
            Lotte Cinema Facebook
          </a>
          <div class="navLuncher_fb-mess" ref="socialFb">
            Tin tức mới nhất, sự kiện xem trước!
          </div>
        </div>
      </div>
      <div class="navLuncher_login_user">
        <p class="nav_change-txt" v-show="!isLogin" @click="goToLogin">
          Đăng nhập
        </p>
        <p class="nav_change-txt" v-show="isLogin" @click="logout">Đăng xuất</p>
        <p class="nav_change-txt" v-show="isLogin" @click="goUserInfo">
          Tài khoản của tôi
        </p>
        <p class="nav_change-txt" v-show="isLogin">Lịch sử mua vé</p>
        <p class="nav_change-txt" v-show="isLogin">Phim đã xem</p>
      </div>
    </div>
  </div>
</template>
<script setup>
import router from "@/Router/router";
import { store } from "@/store/store";
import { computed, onMounted } from "vue";

onMounted(() => {
  store.dispatch("loadIsLoginUser");
});

const isLogin = computed(() => store.getters["getIsLoginUser"]);

const goUserInfo = () => {
  router.push("/User%20Information");
};

const goToLogin = () => {
  router.push("/Login");
};

const logout = () => {
  window.sessionStorage.setItem("token", "");
  store.dispatch("loadIsLoginUser");
};
</script>
<style scoped>
.navLuncher {
  width: 100%;
  height: 30px;
  background-color: rgb(239, 235, 219);
}
.navLuncher .navLuncher_ctn {
  width: 80%;
  height: 100%;
  float: right;
  display: flex;
  justify-content: space-between;
}
.navLuncher .navLuncher_ctn .navLuncher_social {
  display: flex;
  height: 100%;
}
.navLuncher_ctn .navLuncher_social .navLuncher_app {
  position: relative;
  margin-right: 20px;
  width: 130px;
}
.navLuncher_ctn .navLuncher_social .navLuncher_fb {
  position: relative;
  width: 170px;
}
.navLuncher_social .navLuncher_app > span,
.navLuncher_social .navLuncher_fb > a {
  font-size: 12px;
  color: #555;
  font-weight: 600;
}
.navLuncher_social .navLuncher_app:hover .navLuncher_app-qr {
  display: block;
}
.navLuncher_social .navLuncher_app .navLuncher_app-qr {
  position: absolute;
  top: 105%;
  left: -30%;
  z-index: 5;
  height: auto;
  background-color: white;
  display: none;
  padding: 25px 20px;
  border: 1px solid rgba(0, 0, 0, 0.5);
}
.navLuncher_social .navLuncher_app .navLuncher_app-qr::before {
  content: "";
  position: absolute;
  top: -1.7%;
  left: 45%;
  display: block;
  width: 17px;
  height: 6px;
  background: url(../../../assets/icon_lottecinemaapp_arrow.png) 0 0 no-repeat;
}
.navLuncher_social .navLuncher_fb:hover .navLuncher_fb-mess {
  display: block;
}

.navLuncher_social .navLuncher_fb .navLuncher_fb-mess {
  position: absolute;
  top: 105%;
  left: -6%;
  width: 100%;
  display: none;
  padding: 5px;
  border: 1px solid #2a2e33;
  background: #fff;
  color: #231f20;
  z-index: 5;
  font-size: 12px;
}
.navLuncher_social .navLuncher_fb .navLuncher_fb-mess::before {
  content: "";
  position: absolute;
  top: -10%;
  left: 45%;
  display: block;
  width: 17px;
  height: 6px;
  background: url(../../../assets/icon_lottecinemaapp_arrow.png) 0 0 no-repeat;
}
.navLuncher .navLuncher_ctn .navLuncher_login_user {
  display: flex;
  height: 100%;
  padding-right: 35px;
}
.navLuncher_ctn .navLuncher_login_user .nav_change-txt {
  font-size: 12px;
  color: #6f6247;
  margin: 0;
  cursor: pointer;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 5px;
}
</style>
