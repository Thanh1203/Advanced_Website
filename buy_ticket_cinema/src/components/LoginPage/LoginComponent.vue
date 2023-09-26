<template>
<div class="Login">
    <div class ="wrapper">
        <div id="LoginForm">
            <h1 class="title-login">Login</h1>
            <form action="#">
                <div class="input-group mb-3">
                    <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'user']" style="color: #000000;" /></span>
                    <div class="form-floating">
                        <input type="text" class="form-control" id="floatingInputGroup1" placeholder="Username">
                        <label for="floatingInputGroup1">Username</label>
                    </div>
                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text" id="basic-addon1"><font-awesome-icon :icon="['fas', 'key']" style="color: #000000;" /></span>
                    <div class="form-floating">   
                        <input type="password" class="form-control" id="floatingPassword" placeholder="Password">
                        <label for="floatingPassword">Password</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <div class="form-check form-switch">
                            <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckChecked" checked>
                            <label class="form-check-label" for="inlineFormCheck">
                                Remember me
                            </label>
                        </div>
                    </div>
                    <div class="col">
                        <p class="content-col">Don't have an account? <span class="goRe" @click="goRegister">Register now!</span></p>
                    </div>
                </div>
                <button type="submit" class="btn btn-primary" @click="loginning">Login</button>
            </form>
        </div>
    </div>
</div>
</template>
<script setup>
import router from '@/Router/router';


const goRegister = () => {
    router.push('/Register')
}

const loginning = () => {
    router.push('/')
}

</script>
<style scoped>
.Login 
{
    background-image: url(../../assets/background-login.jpg);
    background-repeat: round;
    height: 571px;
}
.wrapper
{
    padding-top: 30px;
    margin-left: 400px;
}
#LoginForm {
    height: 500px;
    width: 500px;
    background-color: black;
    opacity: 0.8;
    border-radius: 10px;
    box-shadow: 0 0 10px 2px rgb(58, 58, 58);
}
.title-login
{
    padding-top: 50px;
    text-align: center;
    color: rgb(255, 255, 255);
    margin-bottom: 40px;
}
.input-group
{
    width: 450px;
    margin-left:25px;
}
.row
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
    background-color: rgb(236, 193, 95);
    border: solid 1px white;
}
.content-col
{
    margin-left: -50px;
}
.goRe {
    color: rgb(236, 193, 95);
    text-decoration: underline;
    cursor: pointer;
}
.btn-primary
{
    margin-left: 100px;
    width: 300px;
    background-color: black;
    border: solid 1px white;
    border-radius: 50px;
}
</style>