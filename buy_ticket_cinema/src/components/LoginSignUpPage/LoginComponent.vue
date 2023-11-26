<template>
<div class="loginform_login">
    <form class="loginform_ctn" ref="form" novalidate>
        <div class="mb-3">
            <label for="username"  class="form-label"><font-awesome-icon :icon="['fas', 'user']" style="color: #ffffff;" /> Tên đăng nhập</label>
            <input type="text" class="form-control" name="username" v-model="login.username" required>
            <div class="invalid-feedback" ref="validUsername">
                Nhập tên đăng nhập
            </div>
        </div>
        <div class="mb-3">
            <label for="password"  class="form-label"><font-awesome-icon :icon="['fas', 'lock']" style="color: #ffffff;" /> Mật khẩu</label>
            <input type="password" class="form-control" name="password" v-model="login.password" @input="checkInputPassword" required minlength="8">
            <div class="invalid-feedback" ref="validPassword">
                Mật khẩu phải có ít nhất 8 kí tự
            </div>
        </div>
        <div class="mb-3">
            <label>Quên mật khẩu?</label>
        </div>
        <div class="loginform_btn">
            <button type="submit" class="btn btn-outline-light" @click.prevent="goHomePage">Đăng nhập</button>
        </div>
    </form>
</div>
</template>
<script setup>
// import router from '@/Router/router';
import router from '@/Router/router';
import { loginCourseApi } from '@/contantApi/contantApi';
import axios from 'axios';
import { ref } from 'vue';
// import router from '@/Router/router';

const form = ref(null)
const validUsername = ref(null)
const validPassword = ref(null)
let login = ref({
    username: '',
    password: ''
})


function checkInputPassword() {
    if (login.value.password.length > 8 || login.value.password.length == 8) {
        validPassword.value.classList.remove('show')
    }
}

async function goHomePage() {
    if (form.value.checkValidity()) {
        const formData = new FormData()
        formData.append('username', login.value.username)
        formData.append('password', login.value.password)
        try {
            await axios.post(`${loginCourseApi}`, formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            }).then((res) => {
                window.sessionStorage.setItem('token', res.data.token)
                router.push('/')
            })
        } catch (error) {
            console.error(error)
        }
    }
    form.value.classList.add('was-validated')
}

</script>
<style scoped>
@import url('https://fonts.googleapis.com/css?family=Montserrat:400,800');
.loginform_login {
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
    z-index: 2;
    position: absolute;
    left: 0;
    top: 0;
}

.loginform_login .loginform_ctn {
    width: 100%;
}

.loginform_login .loginform_ctn .form-control:focus {
    border-color: rgb(255, 255, 255);
    box-shadow: 0 0 0 0.25rem rgba(255, 255, 255, .5);
}

.loginform_login .loginform_ctn .invalid-feedback {
    color: rgb(255, 255, 255);
}

.loginform_login .loginform_ctn .loginform_btn {
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>