<template>
  <v-form ref="form" v-model="valid" lazy-validation>
    <v-text-field
      v-model="username"
      :counter="25"
      :rules="usernameRules"
      label="用户名"
      required
    ></v-text-field>
    <v-text-field
      v-model="email"
      :counter="25"
      :rules="emailRules"
      type="email"
      label="邮箱"
      required
    ></v-text-field>
    <v-text-field
      v-model="password"
      :counter="16"
      :rules="passwordRules"
      label="密码"
      type="password"
      required
    ></v-text-field>
    <v-text-field
      v-model="confirm_password"
      :counter="16"
      :rules="confirmPasswordRules"
      label="确认密码"
      type="password"
      required
    ></v-text-field>
    <v-btn
      block
      color="primary mt-3"
      :disabled="!valid"
      @click="submit"
    >注册</v-btn>
    <div class="text-xs-center mt-3">
      <router-link to="/account/signin" class="body-2 grey--text">还没有登录？马上去登录！</router-link>
    </div>
  </v-form>
</template>

<script>
export default {
  data: () => ({
    username: null,
    email: null,
    password: null,
    confirm_password: null,

    valid: true,
    usernameRules: [
      v => !!v || '请输入用户名'
    ],
    emailRules: [],
    passwordRules: [],
    confirmPasswordRules: []
  }),
  methods: {
    submit () {
      if (this.$refs.form.validate()) {
        this.$store.dispatch('createUser', {
          username: this.username,
          email: this.email,
          password: this.password,
          confirm_password: this.confirm_password
        })
      }
    }
  }
}
</script>

<style scoped>
a {
  text-decoration: none;
}
</style>
