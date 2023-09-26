<template>
<div class="register">
    <div>
        <div id="ReForm">
            <h1 class="title-register">Register</h1>
            <div class="input-group mb-3">
                <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'at']" style="color: #000000;" /></span>
                <input type="text" class="form-control" placeholder="Your Email" aria-label="Recipient's username" aria-describedby="basic-addon2">
                <span class="input-group-text" id="basic-addon2">@gmail.com</span>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                <input type="text" class="form-control" placeholder="First name" aria-label="First name">
                </div>
                <div class="col-md-6">
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
.register 
{
    background-image: url(../../assets/backgroung-register.jpg);
    object-fit: cover;
    background-repeat: round;
    height: 571px;
}
.register:first-child
{
    padding-top: 40px;
}
#ReForm {
    height: 500px;
    width: 460px;
    margin-left: 430px;
    background-color: rgba(255, 255, 255, 0.2);
    border: solid 3px red;
    box-shadow: 1px 1px 20px 5px red;
    border-radius: 20px;
    
}
.title-register
{
    padding-top: 50px;
    text-align: center;
    color: white;
    margin-bottom: 30px;
}
.input-group
{
    width: 445px;
    margin-left: 5px;
}
.form-control
{
    width: 205px;
    margin-left: 5px;
}
.form-check
{
    margin-left:10px;
}
.form-check-label
{
    color: white;
}
.back-login
{
    margin-left: 230px;
    margin-top: -38px;
    color: white;
}
.goLo{
    color: rgb(219, 212, 212);
    text-decoration: underline;
    cursor: pointer;
}
.btn-primary
{
    
    margin-left: 100px;
    width: 250px;
    border: solid 1px black;
    border-radius: 50px;
    background-color:white;
    color: black;
}
</style>