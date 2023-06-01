<template>
  <div class="carousel">
    <el-carousel height="300px">
      <el-carousel-item v-for="item in bannersData" :key="item">
        <el-image
          style="width: 100%; height: 100%"
          :src="item.imageUrl"
          fit="cover"
        />
      </el-carousel-item>
    </el-carousel>
  </div>
  <HomeContent />
</template>

<script setup>
import { ref, onMounted } from "vue";
import HomeContent from "../components/HomeContent.vue";
import { getBannersData } from "../api";

const bannersData = ref("");

onMounted(async () => {
  await getBannersData().then((res) => {
    bannersData.value = res;
  });
});
</script>

<style lang="less" scoped>
.carousel {
}
</style>
