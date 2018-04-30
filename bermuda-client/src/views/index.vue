<template>
  <div>
    <HomeIndex/>
  </div>
</template>

<script>
import HomeIndex from '@/components/Home/Index'

export default {
  data () {
    return {
      example: 'views/index'
    }
  },
  components: {
    HomeIndex
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
