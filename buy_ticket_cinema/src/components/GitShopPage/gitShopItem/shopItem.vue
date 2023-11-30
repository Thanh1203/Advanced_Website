<template>
<div class="gitShop_list-item" :key="props.id">
    <div class="git_image">
        <img :src="require(`../../../assets/${props.photo}`)">
    </div>
    <div class="git_infor">
        <p>{{ props.title }}</p>
        <p>{{ props.detail }}</p>
    </div>
    <div class="git_price">
        <label>Giá bán online</label>
        <label>{{ props.price }}<span>đ</span></label>
    </div>
</div>
</template>
<script setup>
import { defineProps} from 'vue'

const props = defineProps({
    id: String,
    title: String,
    detail: String,
    price: String,
    photo: String
})


</script>
<style scoped>
.gitShop_list-item{
    background: #fff;
    margin: 7.5px;
}
.git_image {
    width: 230px;
    height: 189px;
    display: flex;
}

.git_infor {
    height: 91px;
    width: 230px;
    padding: 16px 15px 20px;
    border-top: 1px solid #dedede;
}
.git_infor p {
    word-wrap: break-word;
    margin-bottom: 10px;
    font-size: 14px;
}
.git_infor p:first-child{
    color: #231f20;
    font-weight: bold;
}
.git_infor p:last-child{
    color: #6666;
}

.git_price {
    padding: 0 15px;
    border-top: 1px solid #dedede;
    display: flex;
    justify-content: space-between;
    align-items: center;
    height: 42px;
    width: 230px;
    font-weight: bold;
}
.git_price label:first-child {
    color: #777;
    font-size: 12px;
}
.git_price label:last-child {
    font-family: 'linlivertine';
    font-size: 18px;
}
.git_price label:last-child > span {
    font-size: 12px;
    font-family: 'linlivertine';
}
</style>