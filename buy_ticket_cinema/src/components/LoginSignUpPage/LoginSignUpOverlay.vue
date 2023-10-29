<template>
<div class="loginform_overlay">
    <img src="../../assets/logo.png" alt="Logo" class="logo">
    <h2 class="loginform_hello">Xin Chào</h2>
    <p>{{ overlayContent }} <font-awesome-icon :icon="['fas', 'arrow-turn-down']" style="color: #000000;" /></p>
    <div class="loginform_overlay-btn">
        <button type="button" class="btn btn-outline-danger" @click.prevent="goSignUp">{{ btnChangeForm }}</button>
    </div>
</div>
</template>
<script setup>
import { computed } from 'vue';
import { useStore } from 'vuex';

const store = useStore()

const stateInLogin = computed(() => store.getters['getInLoginUser'])
const overlayContent = computed(() => {
    if (stateInLogin.value) {
        return "Chào mừng bạn đã đến với Lotte Cinema đăng ký tài khoản của bạn tại đây"
    } else {
        return 'Chào mừng bạn đã trở lại quay lại đăng nhập tại đây'
    }
})
const btnChangeForm = computed(() => {
    if (stateInLogin.value) {
        return 'Đăng ký ngay!'
    } else {
        return 'Quay lại đăng nhập'
    }
})

const goSignUp = () => {
    if (stateInLogin.value) {
        store.commit('setInLoginUser', false)
    } else {
        store.commit('setInLoginUser', true)
    }
}
</script>
<style scoped>
.loginform_overlay {
    background-color: rgb(255, 255, 255);
    height: 100%;
    width: 50%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    padding: 0 40px;
    transform: translateX(0);
    transition: transform 0.6s ease-in-out;
    position: absolute;
    top: 0;
    left: 50%;
    z-index: 100;
}

.loginform_overlay .logo {
    width: 100%;
}
.loginform_overlay .loginform_hello {
    color: rgb(0, 0, 0);
    font-family: 'Montserrat', sans-serif;
    font-weight: 800;
    height: 35px;
    margin: 0 0 16px 0;
}
.loginform_overlay p {
    margin: 0;
    text-align: center;
}
.loginform_overlay .loginform_overlay-btn {
    padding-top: 10.67px;
}

</style>