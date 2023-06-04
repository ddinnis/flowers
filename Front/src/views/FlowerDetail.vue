<template>
  <el-image
    style="width: 300px; height: 200px"
    :src="flowersData.image"
    :zoom-rate="1.2"
    fit="cover"
  />
  <div class="content">
    <div class="title">{{ flowersData.title }}</div>
    <div class="price">{{ flowersData.price }}</div>
  </div>
  <el-button @click="buyFlowers">点击购买</el-button>
</template>

<script setup>
import { onMounted, ref } from "vue";
import { getFlowersData } from "../api";
import { useRoute, useRouter } from "vue-router";
import { ElMessage } from "element-plus";

const { query } = useRoute();

const flowersData = ref("");
// const param = { Id: 0, Type: 0 };
onMounted(async () => {
  await getFlowersData(query).then((res) => {
    flowersData.value = res.data[0];
  });
  console.log("flowersData", flowersData.value);
});

const router = useRouter(query);
const { id, type } = query;
const buyFlowers = () => {
  // 验证用户是否登录
  if (localStorage.getItem("nickName")) {
    ElMessage.warning("请先登录再点击购买！");
  }

  // 生成订单

  router.push({ path: "/pay", query: { id, type } });
};
</script>

<style lang="less" scoped></style>
