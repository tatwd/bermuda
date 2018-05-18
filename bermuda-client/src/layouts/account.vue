<template>
  <div class="layout--account">
    <v-app class="account-page">
      <v-content>
        <v-container fill-height>
          <v-layout row wrap justify-center>
            <v-flex xs12 class="mt-3">
              <div class="text-xs-center">
                <v-avatar size="96px">
                  <img src="@/assets/bmd-logo.svg" alt="Bermuda Logo">
                </v-avatar>
                <h1 class="primary--text">
                  <router-link to="/">百慕大</router-link>
                </h1>
                <h2>寻找你的寻找</h2>
              </div>
              <v-card class="sign-form px-4 py-3 mt-3 mx-auto">
                <router-view/>
              </v-card>
            </v-flex>
          </v-layout>
        </v-container>
      </v-content>
    </v-app>
    <canvas id="particle-animation"></canvas>
  </div>
</template>

<script>
import particleAnimation from '@/assets/js/particle-animation'

export default {
  name: 'account',
  mounted () {
    particleAnimation(document.querySelector('#particle-animation'), { color: '#fdeeeb' })
  }
}
</script>

<style scoped>
#particle-animation {
  width: 100%;
  height: 100%;

  position: absolute;
  top: 0;
  z-index: -1;
}

.account-page {
  background-color: transparent;
}

.sign-form {
  max-width: 320px;
}

a {
  text-decoration: none;
}
</style>
