<template>
  <v-form v-model="valid">
    <v-text-field
      v-model="username"
      :counter="25"
      :rules="usernameRules"
      label="用户名"
      required
    ></v-text-field>
    <v-text-field
      v-model="password"
      :counter="16"
      :rules="passwordRules"
      label="密码"
      required
    ></v-text-field>

    <v-btn block color="primary" submit dark>登录</v-btn>
  </v-form>
</template>

<script>
export default {
  name: 'SignIn',
  data: () => ({
    username: null,
    password: null,

    valid: false,
    usernameRules: [],
    passwordRules: []
  })
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
