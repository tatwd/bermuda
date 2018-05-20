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
      v-model="password"
      :counter="16"
      :rules="passwordRules"
      label="密码"
      type="password"
      required
    ></v-text-field>
    <v-btn
      block
      color="primary mt-3"
      :disabled="!valid"
      @click="submit"
    >登录</v-btn>
    <div class="text-xs-center mt-3">
      <router-link to="/account/signup" class="body-2 grey--text">还没有账户？马上去注册！</router-link>
    </div>
  </v-form>
</template>

<script>
export default {
  data: () => ({
    username: null,
    password: null,

    valid: true
  }),
  computed: {
    usernameRules () {
      return [
        v => !!v || '请输入用户名',
      ]
    },
    passwordRules () {
      return [
        v => !!v || '请输入密码',
        v => (v && v.length >= 6 && v.length <= 16) || '注意密码的长度'
      ]
    }
  },
  methods: {
    submit () {
      console.log(this.$router.path)
      if (this.$refs.form.validate()) {
        this.$store.dispatch('signin', {
          user: {
            username: this.username,
            password: this.password
          },
          redirect: () => this.$router.go({
            path: this.$router.path
          })
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
