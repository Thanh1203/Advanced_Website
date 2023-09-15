<template>
    <div class="contact_container">
        <div class="contact_group">
            <div class="contact_item"></div>
            <div class="contact_item"></div>
            <div class="contact_item"></div>
        </div>
    </div>
</template>
<script>
export default {
    setup() {
        return {

        }
    }
}
</script>
<style scoped>
.contact_container {
    height: 100px;
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: aquamarine;
}

.contact_group {
    flex-basis: 80%;
}


</style>