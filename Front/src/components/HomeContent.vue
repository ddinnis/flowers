<template>
  <el-container>
    <el-header>
      <div class="left-text">爱情鲜花</div>
      <el-link src="/love">送 · 让你砰然心动的人</el-link>
      <div class="more">更多爱情鲜花</div>
    </el-header>
    <el-container>
      <el-aside width="300px">
        <el-image
          style="width: 300px; height: 450px"
          src="https://imgapi.cn/api.php?zd=mobile&fl=fengjing&gs=images"
          fit="cover"
        />
      </el-aside>
      <el-main>
        <div class="img" v-for="item in 6" :key="item">
          <el-image
            style="width: 300px; height: 200px"
            src="https://fuss10.elemecdn.com/a/3f/3302e58f9a181d2509f3dc0fa68b0jpeg.jpeg"
            :zoom-rate="1.2"
            fit="cover"
          />
          <div class="content">
            <div class="title"></div>
            <div class="price"></div>
          </div>
        </div>
      </el-main>
    </el-container>
  </el-container>
</template>

<script setup>
import { onMounted, ref } from "vue";
import { getFlowersData } from "../api";

const flowersData = ref("");
onMounted(async () => {
  flowersData.value = await getFlowersData();
  console.log("flowersData.value", flowersData.value);
});
</script>

<style lang="less" scoped>
.el-container {
  margin-bottom: 50px;
}
.el-header {
  display: flex;
  margin: 25px 0 0;
  justify-content: space-around;
}

.img {
  display: inline-block;
  .el-image {
    display: flex;
    padding: 0 10px 20px;
  }
}

.el-main {
  display: flex;
  flex-wrap: wrap;

  --el-main-padding: 0 20px;
}
</style>
