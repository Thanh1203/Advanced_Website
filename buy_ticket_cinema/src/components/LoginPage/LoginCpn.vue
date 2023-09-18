<template>
    <div class="Login_ctn">
        <h1>Login</h1>
        <div class="login_form">
            <form>
                <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Email address</label>
                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                </div>
                <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Password</label>
                    <input type="password" class="form-control" id="exampleInputPassword1">
                </div>
                <div class="mb-3 form-check">
                    <div class="form-check_tiem">
                        <input type="checkbox" class="form-check-input" id="exampleCheck1">
                        <label class="form-check-label" for="exampleCheck1">Check me out</label>
                    </div>
                    <div class="form-check_tiem">
                        <p>No account? <span>Register</span></p>
                    </div>
                </div>
                <button type="submit" class="btn btn-primary">Login</button>
            </form>
        </div>
    </div>
</template>
<script>
export default {

}
</script>
<style scoped>
.Login_ctn{
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    padding: 20px;
}

.form-check{
    display: flex;
    justify-content: space-between;
}
</style>