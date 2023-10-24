<template>
<div id="Login">
    <div class="Login-img">
        <img src="../../assets/favicon.png" alt="Logo" class="logo1">
        <img src="../../assets/logo.png" alt="Logo" class="logo2">
    </div>
    <div class="LoginForm">
        <h1 class="title-login">Login</h1>
        <form class="login-form" ref="form" novalidate>
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'user']" style="color: #000000;" /></span>
                <div class="form-floating">
                    <input type="text" class="form-control" placeholder="Username" required>
                    <label>Username</label>
                </div>
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'key']" style="color: #000000;" /></span>
                <div class="form-floating">   
                    <input type="password" class="form-control" placeholder="Password" required>
                    <label>Password</label>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <div class="form-check form-switch formcheck-cus">
                        <input class="form-check-input" type="checkbox" role="switch" checked>
                        <label class="form-check-label">
                            Remember me
                        </label>
                    </div>
                </div>
                <div class="col">
                    <p class="content-col">Don't have an account? <span class="goRe" @click="goRegister">Register now!</span></p>
                </div>
            </div>
            <button type="submit" class="btn btn-primary" @click.prevent="loginning">Login</button>
        </form>
    </div>
</div>
</template>
<script setup>
import router from '@/Router/router';
import { ref } from 'vue';

const form = ref(null)
// const errorMess = ref(null)
const goRegister = () => {
    router.push('/Register')
}

const loginning = () => {
    if (form.value.checkValidity()) {
        router.push('/')
    } else {
        form.value.classList.add('was-validated')
    }
}

</script>
<style scoped>
#Login 
{
    background-image: url(../../assets/background-login.jpg);
    background-repeat: no-repeat;
    background-size: cover;
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
}

.Login-img {
    width: 500px;
    height: 500px;
    background-color: white;
    align-self: center;
    border: 1px solid rgb(80, 80, 80);
    border-top-left-radius: 10px;
    border-bottom-left-radius: 10px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.Login-img .logo1 {
    margin: 0 auto;
    height: 100px;
}

.Login-img .logo2 {
    margin: 0 auto;
    height: 73px;
}

.LoginForm {
    height: 500px;
    width: 500px;
    background-color: white;
    border-top-right-radius: 10px;
    border-bottom-right-radius: 10px;
    border: 1px solid rgb(80, 80, 80);
    align-self: center;
}

.LoginForm .title-login {
    padding-top: 50px;
    text-align: center;
    color: rgb(218, 41, 28);
    margin-bottom: 40px;
    font-weight: 700;
}

.LoginForm .login-form {
    text-align: center;
}
.input-group
{
    width: 450px;
    margin-left:25px;
}
.login-form .row
{
    display: flex;
    margin-left: 25px;
    margin-top: 30px;
    color: rgb(195, 193, 193);
    font-size: 14px;
    margin-bottom:80px;
}

#flexSwitchCheckChecked
{
    border: solid 1px white;
}

.formcheck-cus{
    width: 150px;
}

.form-check-input:checked{
    background-color: rgb(218, 41, 28);
}
.content-col
{
    margin-left: -50px;
}
.goRe {
    color: rgb(218, 41, 28);
    text-decoration: underline;
    cursor: pointer;
}
.btn-primary
{
    margin: 0 auto;
    width: 300px;
    background-color: black;
    border: solid 1px white;
    border-radius: 50px;
}
</style>