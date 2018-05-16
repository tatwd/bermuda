<template>
  <v-card class="sign-form mt-3 mx-auto" flat>
    <v-form v-model="valid">
      <v-text-field
        v-model="username"
        :counter="25"
        :rules="usernameRules"
        label="用户名"
        required
        solo
      ></v-text-field>
      <!-- <v-divider></v-divider> -->
      <v-text-field
        v-model="password"
        :counter="16"
        :rules="passwordRules"
        label="密码"
        required
        solo
      ></v-text-field>
      <v-btn block color="primary mt-3" submit dark>登录</v-btn>
      <div class="text-xs-center mt-3">
        <router-link to="/account/signup" class="body-2 grey--text">还没有账户？马上去注册！</router-link>
      </div>
    </v-form>
  </v-card>
</template>

<script>
export default {
  data () {
    return {
      username: null,
      password: null,

      valid: false,
      usernameRules: [],
      passwordRules: []
    }
  }
}
</script>

<style scoped>
.sign-form {
  max-width: 280px;
}
a {
  text-decoration: none;
}
</style>
