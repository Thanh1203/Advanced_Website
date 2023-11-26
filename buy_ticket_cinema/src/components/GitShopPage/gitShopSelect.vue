<template>
<div class="gitShopSelect_ctn">
    <div class="gitShopSelectItem" :class="{action : selected == 0}" @click="changeSelected(0)">
        <label>Bán Chạy nhất</label>
    </div>
    <div class="gitShopSelectItem" :class="{ action: selected == 1 }" @click="changeSelected(1)">
        <label>Danh Mục Hàng Bán</label>
    </div>
    <div class="gitShopSelectItem" :class="{ action: selected == 2 }" @click="changeSelected(2)">
        <label>Lotte Combo</label>
    </div>
</div>
</template>
<script setup>
import { store } from '@/store/store';
import { computed } from 'vue';

const selected = computed(() => store.getters['getSelectGitShop']);

const changeSelected = (index) => {
    store.dispatch('changeSelectGitshop', index)
}

</script>
<style scoped>
.gitShopSelect_ctn {
    width: 100%;
    display: flex;
}

.gitShopSelect_ctn .gitShopSelectItem {
    width: calc(100% /3);
    border: 1px solid #cdc197;
    height: 50px;
    display: flex;
    justify-content: center;
    align-items: center;
}

.gitShopSelect_ctn .gitShopSelectItem:first-child {
    border: 1px solid #cdc197;
    border-right: none;
}

.gitShopSelect_ctn .gitShopSelectItem:last-child {
    border: 1px solid #cdc197;
    border-left: none;
}

.gitShopSelect_ctn .gitShopSelectItem > label {
    font-weight: bold;
}

.gitShopSelect_ctn .gitShopSelectItem.action {
    background-color: #cdc197;
}
</style>