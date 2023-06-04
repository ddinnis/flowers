<template>
  <h1>PAY</h1>
  <el-button @click="handlePay">点击支付</el-button>
</template>

<script setup>
import { useRoute, useRouter } from "vue-router";
import { CreateOrder } from "../api";
import { ElMessage } from "element-plus";

const router = useRouter();
const { query } = useRoute();
const { id } = query;
const handlePay = async () => {
  if (localStorage.getItem("nickName")) {
    ElMessage.warning("请先登录再点击购买！");
  }
  try {
    let res = (await CreateOrder({ FlowerId: id })).data;
    console.log("first", res);
    if (res.isSuccess) {
      ElMessage({
        message: "创建订单成功",
        type: "success",
      });
      router.push({ path: "personcenter" });
    } else {
      ElMessage.warning("创建订单失败！");
    }
  } catch (error) {
    ElMessage.warning("请登录后刷新列表");
  }
};
</script>

<style lang="less" scoped></style>
