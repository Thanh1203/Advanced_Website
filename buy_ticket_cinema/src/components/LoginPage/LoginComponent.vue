<template>
<div id="LoginForm">
    <h1>Login</h1>
    <!-- Thêm khoảng cách và thêm màu chọn một màu phù hợp và thg register cũng màu này nhé -->
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
            <!-- css cho a cho a phần này sao cho các chữ cái đều cùng một dòng -->
            <div class="col">
                <div class="form-check form-switch">
                    <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckChecked" checked>
                    <label class="form-check-label" for="inlineFormCheck">
                        Remember me
                    </label>
                </div>
            </div>
            <div class="col">
                <p>Don't have an account? <span class="goRe" @click="goRegister">Register now!</span></p> 
                <!-- Phần Register now e có chọn màu tùy thích nhé a css tạm trước thôi -->
            </div>
        </div>
        <button type="submit" class="btn btn-primary" @click="loginning">Login</button>
        <!-- Đưa thg button này ra giữa và tăng chiều dài nó ra nhé đổi màu cùng với các thg kia -->
    </form>
</div>
<!-- set lại toàn bộ màu cho đẹp e nhé tăng khoảng cách các phần tử sao cho ưng mắt nhất nhé tùy biến background sao cho thật cool-->
<!-- set border cong lại nhìn mêm cho thích mắt e nhé -->
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
#LoginForm {
    height: 500px;
    width: 500px;
    background-color: rgb(160, 158, 156);
    margin: 50px auto 0;
    padding: 10px;
}

.goRe {
    color: blue;
    text-decoration: underline;
    cursor: pointer;
}
</style>