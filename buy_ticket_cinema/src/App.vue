<template>
  <router-view>

  </router-view>
</template>

<script>

export default {
  name: 'App',
  components: {}
}
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
