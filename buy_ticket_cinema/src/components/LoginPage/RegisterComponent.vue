<template>
<div id="ReForm">
    <!-- Chỉnh toàn bộ sao cho đẹp mắt nhé -->
    <!-- Màu của của phần này phải khác với màu bên login nhé -->
    <h1>Register</h1>
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
    <div class="mb-3">
        <p>Have an account? <span class="goLo" @click="goLogin">Let's Login</span></p>
    </div>
    <button type="submit" class="btn btn-primary">Register</button>
</div>
</template>
<script setup>
import router from '@/Router/router';

const goLogin = () => {
    router.push('/Login')
}
</script>
<style scoped>
#ReForm {
    height: 500px;
    width: 500px;
    margin: 50px auto 0;
    background-color: aquamarine;
    padding: 10px;
}

.goLo{
    color: blue;
    text-decoration: underline;
    cursor: pointer;
}
</style>