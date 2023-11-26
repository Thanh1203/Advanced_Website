<template>
    <div class="gitShop_group-item" ref="gitlist">
        <p class="lb_title">Bán Chạy Nhất</p>
        <div class="git_list">
            <shopItem class="git_Item" v-for="item in gitlists" :key="item.id" :title="item.name" :detail="item.detail" :price="item.price"/>
        </div>

    </div>
    <div class="gitShop_group-item" ref="gitlist2">
        <p class="lb_title">Danh Mục Bán Hàng</p>
        <div class="git_list">
            <shopItem  class="git_Item" v-for="item in gitlists2" :key="item.id" :title="item.name" :detail="item.detail" :price="item.price"/>
        </div>
    </div>
    <div class="gitShop_group-item" ref="lotteCombo">
        <p class="lb_title">Lotte Combo</p>
        <div class="git_list">
            <shopItem class="git_Item" v-for="item in lotteCombos" :key="item.id" :title="item.name" :detail="item.detail" :price="item.price"/>
        </div>
    </div>
</template>
<script setup>
import { computed, ref } from 'vue';
import shopItem from './gitShopItem/shopItem';
import { store } from '@/store/store';

const selected = computed(() => store.getters['getSelectGitShop']);
console.log(selected);

const gitlists = ref([
    {
        id: "tiketgit1",
        name: "Vé Xem Phim 2D",
        detail: "Hạn sử dụng sản phẩm | 12 tháng",
        price: "120.000"
    },
    {
        id: "tiketgit2",
        name: "Vé Charlotte 2D",
        detail: "Hạn sử dụng sản phẩm | 12 tháng",
        price: "300.000"

    },
    {
        id: "tiketgit3",
        name: "Vé Cine Comfort 2D",
        detail: "Hạn sử dụng sản phẩm | 12 tháng",
        price: "180.000"

    },
    {
        id: "tiketgit4",
        name: "Vé Super Plex 2D",
        detail: "Hạn sử dụng sản phẩm | 12 tháng",
        price: "130.000"

    },
])
let gitlist = ref(null)

const gitlists2 = ref([
    {
        id: "tiketgit1",
        name: "Vé Xem Phim 2D",
        detail: "Hạn sử dụng sản phẩm | 12 tháng",
        price: "120.000"
    },
    {
        id: "tiketgit2",
        name: "Vé Charlotte 2D",
        detail: "Hạn sử dụng sản phẩm | 12 tháng",
        price: "300.000"

    },
    {
        id: "tiketgit3",
        name: "Vé Cine Comfort 2D",
        detail: "Hạn sử dụng sản phẩm | 12 tháng",
        price: "180.000"

    },
    {
        id: "tiketgit4",
        name: "Vé Super Plex 2D",
        detail: "Hạn sử dụng sản phẩm | 12 tháng",
        price: "130.000"

    }
])
let gitlist2 = ref(null)

const lotteCombos = ref([
    {
        id: "lotteCombo1",
        name: "Crunchy Couple Combo",
        detail: "Hạn sử dụng sản phẩm | 3 tháng",
        price: "157.091"
    },
    {
        id: "lotteCombo2",
        name: "Crunchy Combo",
        detail: "Hạn sử dụng sản phẩm | 3 tháng",
        price: "128.618"
    },
    {
        id: "lotteCombo3",
        name: "Harmony Plus",
        detail: "Hạn sử dụng sản phẩm | 3 tháng",
        price: "132.545"
    },
])
let lotteCombo = ref(null)

</script>
<style scoped>
.gitShop_group-item {
    width: 100%;
}

.gitShop_group-item .lb_title {
    font-size: 18px;   
    font-weight: bold;
    color: #231f20;
    margin-bottom: 18px;
    padding-top: 30px;
    padding-left: 7.5px;
}

.gitShop_group-item .git_list {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
}
</style>