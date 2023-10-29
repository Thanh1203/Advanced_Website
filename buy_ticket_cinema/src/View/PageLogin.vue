<script setup>
import LoginComponent from '@/components/LoginSignUpPage/LoginComponent.vue';
import LoginSignUpOverlay from '@/components/LoginSignUpPage/LoginSignUpOverlay.vue';
import SignUpComponent from '@/components/LoginSignUpPage/SignUpComponent.vue';
import { computed, ref, watch } from 'vue';
import { useStore } from 'vuex';

const store = useStore()
const inLoginState = computed(() => store.getters['getInLoginUser'])

const loginTitle = computed(() => {
    if (inLoginState.value) {
        return 'Đăng nhập'
    } else {
        return 'Đăng ký'
    }
})

const container = ref(null)
watch(inLoginState, (newValue) => {
    if (newValue) {
        container.value.classList.remove('right-panel-active')
    } else {
        container.value.classList.add('right-panel-active')
    }
})
</script>
<template>
<div id="Login">
    <h1 class="login_title">{{ loginTitle }}</h1>
    <div class="loginform" ref="container">
        <SignUpComponent/>
        <LoginComponent/>
        <LoginSignUpOverlay/>
    </div>
</div>
</template>
<style scoped>
#Login 
{
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    background-color: whitesmoke;
}
#Login .login_title {
    margin-bottom: 20px;
    font-weight: bold;
    color: rgb(218, 41, 28);
    letter-spacing: 2px;
}
#Login .loginform {
    min-height: 480px;
    width: 768px;
    max-width: 100%;
    border-radius: 10px;
    box-shadow: 0 14px 28px rgba(0, 0, 0, 0.25), 0 10px 10px rgba(0, 0, 0, 0.22);
    position: relative;
    display: block;
    overflow: hidden;
}

.loginform.right-panel-active .loginform_login {
    transform: translateX(100%);
}

.loginform.right-panel-active .loginform_signUp {
    transform: translateX(100%);
    opacity: 1;
    z-index: 5;
    animation: show 0.6s;
}

.loginform.right-panel-active .loginform_overlay {
    transform: translateX(-100%);
}

@keyframes show {

    0%,
    49.99% {
        opacity: 0;
        z-index: 1;
    }

    50%,
    100% {
        opacity: 1;
        z-index: 5;
    }
}
</style>