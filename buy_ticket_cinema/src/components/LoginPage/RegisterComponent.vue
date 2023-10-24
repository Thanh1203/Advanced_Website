<template>
<div id="register">
    <div class="register-img">
            <img src="../../assets/favicon.png" alt="Logo" class="logo1">
            <img src="../../assets/logo.png" alt="Logo" class="logo2">
    </div>
    <div class="ReForm">
        <h1 class="title-register">Register</h1>
        <form class="re-form" ref="form" novalidate>
            <div class="input-group mb-3">
                <span class="input-group-text"><font-awesome-icon :icon="['fas', 'at']" style="color: #000000;" /></span>
                <input type="text" class="form-control" placeholder="Your Email" required>
                <span class="input-group-text">@gmail.com</span>
            </div>
            <div class="row mb-3 input-group">
                <div class="input-name">
                <input type="text" class="form-control" placeholder="First name" aria-label="First name" required>
                </div>  
                <div class="input-name">
                <input type="text" class="form-control" placeholder="Last name" aria-label="Last name" required>
                </div>
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text"><font-awesome-icon :icon="['fas', 'user']" style="color: #000000;" /></span>
                <input type="text" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1" required>
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text"><font-awesome-icon :icon="['fas', 'key']" style="color: #000000;" /></span>
                <input type="password" class="form-control" placeholder="Password" required>
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text"><font-awesome-icon :icon="['fas', 'check-double']" style="color: #000000;" /></span>
                <input type="password" class="form-control" placeholder="Confirm password" required>
            </div>
            <div class="mb-3 form-check">
                <input type="checkbox" class="form-check-input" required>
                <label class="form-check-label">Agree to the terms</label>
            </div>
            <div class="back-login mb-3">
                <p>Have an account? <span class="goLo" @click="goLogin">Let's Login</span></p>
            </div>
            <button type="submit" class="btn btn-primary" @click.prevent="registerring">Register</button>
        </form>
    </div>
</div>
</template>
<script setup>
import router from '@/Router/router';
import { ref } from 'vue';

const goLogin = () => {
    router.push('/Login')
}

const form = ref(null)

const registerring = () => {
    if (form.value.checkValidity()) {
        router.push('/')
    } else {
        form.value.classList.add('was-validated')
    }
}
</script>
<style scoped>
#register 
{
    background-image: url(../../assets/backgroung-register.jpg);
    background-repeat: no-repeat;
    background-size: cover;
    width: 100%;
    height: 100%;
    display: flex;
    justify-content: center;
}

.register-img {
    width: 500px;
    height: 550px;
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

.register-img .logo1 {
    margin: 0 auto;
    height: 100px;
}

.register-img .logo2 {
    margin: 0 auto;
    height: 73px;
}

.ReForm {
    height: 550px;
    width: 500px;
    background-color: white;
    border: 1px solid rgb(80, 80, 80);
    border-top-right-radius: 10px;
    border-bottom-right-radius: 10px;
    align-self: center;
    padding: 0 10px;
    text-align: center;
}
.ReForm .title-register{
    padding-top: 50px;
    text-align: center;
    color: rgb(218, 41, 28);
    margin-bottom: 30px;
}

.re-form .row {
    justify-content: space-between;
    margin-left: 0;
}

.re-form .row .input-name{
    padding: 0;
    flex-basis: 48%;
    --bs-gutter-x: none;
}

.re-form .form-check{
    text-align: start;
}

.re-form .form-check .form-check-label
{
    color: rgb(218, 41, 28);
}

.re-form .form-check .form-check-input{
    border: rgb(218, 41, 28) 1px solid;
}

.re-form .back-login{
    width: 100%;
    color: rgb(218, 41, 28);
    text-align: start;
}
.re-form .back-login .goLo{
    color: black;
    text-decoration: underline;
    cursor: pointer;
}


.re-form .btn-primary
{
    width: 250px;
    border: solid 1px black;
    border-radius: 50px;
    background-color:white;
    color: black;
}
</style>