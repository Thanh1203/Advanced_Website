<template>
<div class="loginform_signUp">
    <form class="loginform_ctn" ref="form" novalidate>
        <div class="input-group mb-3">
            <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'user-pen']" style="color: #000000;" /></span>
            <input type="text" class="form-control" name="username" v-model="signUp.username"  placeholder="Tên đăng nhập" required>
            <div class="invalid-feedback" ref="validUsername">
                Nhập tên đăng nhập
            </div>
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'lock']" style="color: #000000;" /></span>
            <input type="password" class="form-control" name="password" v-model="signUp.password" placeholder="Mật khẩu" required minlength="8">
            <div class="invalid-feedback" ref="validPassword">
                Mật khẩu phải có ít nhất 8 kí tự
            </div>
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'check']" style="color: #000000;" /></span>
            <input type="password" class="form-control" name="password" v-model="signUp.passCheck" placeholder="Nhập lại mật khẩu" required :pattern="`${signUp.password}`">
            <div class="invalid-feedback" ref="validPassCheck">
                Mật khẩu nhập lại không giống nhau
            </div>
        </div>
        <div class="form-check mb-3">
            <input class="form-check-input" type="checkbox" value="" checked required>
            <label class="form-check-label" for="flexCheckChecked">
                Tôi đồng ý với điều khoản sử dụng của Lotte Cinema
            </label>
        </div>
        <div class="loginform_btn">
            <button type="submit" class="btn btn-outline-light" @click.prevent="goHomePage">Đăng nhập</button>
        </div>
    </form>
</div>
</template>
<script setup>
// import router from '@/Router/router';
import { ref } from 'vue';

const form = ref(null)
const validUsername = ref(null)
const validPassword = ref(null)
const validPassCheck = ref(null)
let signUp = ref({
    username: '',
    password: '',
    passCheck: ''
})

function goHomePage() {
    if (form.value.checkValidity()) {
        console.log(`username: ${signUp.value.username} , password: ${signUp.value.password}`);
        // router.push('/')
    }
    form.value.classList.add('was-validated')
}

</script>
<style scoped>
.loginform_signUp {
    width: 50%;
    height: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    padding: 0 40px;
    background-color: rgb(218, 41, 28);
    color: rgb(255, 255, 255);
    transition: all 0.6s ease-in-out;
    opacity: 0;
    position: absolute;
    left: 0;
    top: 0;
    z-index: 1;
}

.loginform_signUp .loginform_ctn {
    width: 100%;
}

.loginform_signUp .loginform_ctn .form-control:focus {
    border-color: rgb(255, 255, 255);
    box-shadow: 0 0 0 0.25rem rgba(255, 255, 255, .5);
}

.loginform_signUp .loginform_ctn .invalid-feedback {
    color: rgb(255, 255, 255);
}

.loginform_signUp .loginform_ctn .loginform_btn {
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
}

.was-validated .form-check-input:valid~.form-check-label {
    color: rgb(255, 255, 255);
}
</style>