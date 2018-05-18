<template>
  <div id="app">
    <transition name="slide-fade">
      <router-view/>
    </transition>
  </div>
</template>

<script>
// import Navbar from './components/shared/Navbar'

export default {
  name: 'App',
}
</script>

<style>
.fade-enter-active {
  transition: all .3s ease;
}

.fade-leave-active {
  transition: all .8s cubic-bezier(1.0, 0.5, 0.8, 1.0);
}

.fade-enter,
.fade-leave-to {
  transform: translateX(16px);
  opacity: 0;
}
</style>
