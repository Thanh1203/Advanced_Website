<template>
<div id="register">
    <div class="ReForm">
        <h1 class="title-register">Register</h1>
        <div class="input-group mb-3">
            <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'at']" style="color: #000000;" /></span>
            <input type="text" class="form-control" placeholder="Your Email" aria-label="Recipient's username" aria-describedby="basic-addon2">
            <span class="input-group-text" id="basic-addon2">@gmail.com</span>
        </div>
        <div class="row mb-3 input-group">
            <div class="input-name">
            <input type="text" class="form-control" placeholder="First name" aria-label="First name">
            </div>  
            <div class="input-name">
            <input type="text" class="form-control" placeholder="Last name" aria-label="Last name">
            </div>
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'user']" style="color: #000000;" /></span>
            <input type="text" class="form-control" placeholder="Username" aria-label="Username" aria-describedby="basic-addon1">
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'key']" style="color: #000000;" /></span>
            <input type="password" class="form-control" id="inputPassword3" placeholder="Password">
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'check-double']" style="color: #000000;" /></span>
            <input type="password" class="form-control" id="inputPassword3" placeholder="Confirm password">
        </div>
        <div class="mb-3 form-check">
            <input type="checkbox" class="form-check-input" id="exampleCheck1">
            <label class="form-check-label" for="exampleCheck1">Agree to the terms</label>
        </div>
        <div class="back-login mb-3">
            <p>Have an account? <span class="goLo" @click="goLogin">Let's Login</span></p>
        </div>
        <button type="submit" class="btn btn-primary" @click="registerring">Register</button>
    </div>
</div>
</template>
<script setup>
import router from '@/Router/router';

const goLogin = () => {
    router.push('/Login')
}

const registerring = () => {
    router.push('/')
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
.ReForm {
    height: 550px;
    width: 500px;
    background-color: transparent;
    backdrop-filter: blur(20px);
    border: solid 3px red;
    box-shadow: 0 0 20px 5px red;
    border-radius: 20px;
    align-self: center;
    padding: 0 10px;
    text-align: center;
}
.title-register
{
    padding-top: 50px;
    text-align: center;
    color: white;
    margin-bottom: 30px;
}
.form-check-label
{
    color: white;
}
.back-login
{
    width: 100%;
    color: white;
    text-align: start;
}
.goLo{
    color: red;
    text-decoration: underline;
    cursor: pointer;
}
.btn-primary
{
    width: 250px;
    border: solid 1px black;
    border-radius: 50px;
    background-color:white;
    color: black;
}

.row {
    justify-content: space-between;
    margin-left: 0;
}

.input-name{
    padding: 0;
    flex-basis: 48%;
    --bs-gutter-x: none;
}

.form-check{
    text-align: start;
}
</style>