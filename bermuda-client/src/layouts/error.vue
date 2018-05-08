<template>
  <div id="layout--error">
    <div class="error-message">
      <div class="logo-img">
        <img src="@/assets/bmd-logo.svg" alt="Bermuda Logo">
      </div>
      <h2 class="display-4 red--text">{{ errorMsg }}</h2>
      <p class="display-1 mt-4">
        <router-link to="/">{{ linkMsg }}</router-link>
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: 'error',
  data: () => ({
    errorMsg: '404',
    linkMsg: '返回首页'
  })
}
</script>

<style scoped>
#layout--error {
  display: flex;
  height: 100vh
}

.error-message {
  margin: auto;
  text-align: center
}

a {
  text-decoration: none;
  color: #222;
}
</style>
