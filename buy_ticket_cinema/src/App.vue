<template>
  <router-view>
  </router-view>
</template>

<script setup>
import { useStore } from 'vuex';
import { onMounted } from 'vue';
// import { getApiData } from '@/contantApi/getDataApi';

const store = useStore()

// console.log(getApiData().then(data => data.slidePhotos));
onMounted(() => {
  store.dispatch('loadProducts')
  store.dispatch('loadEvents')
  store.dispatch('loadSlide')
})
</script>

<style>
#app{
  height: 100%;
}
.page-opacity-enter-active,
.page-opacity-leave-active {
  transition: 0.6s ease all;
}

.page-opacity-enter-from,
.page-opacity-leave-to {
  opacity: 0;
}
</style>
