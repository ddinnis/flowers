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
        <div
          class="flower-item"
          v-for="item in flowersData"
          :key="item.id"
          @click="toFlowerDetail({ id: item.id, type: item.type })"
        >
          <el-image
            style="width: 300px; height: 200px"
            :src="item.image"
            :zoom-rate="1.2"
            fit="cover"
          />
          <div class="content">
            <div class="title">{{ item.title }}</div>
            <div class="price">{{ item.price }}</div>
          </div>
        </div>
      </el-main>
    </el-container>
  </el-container>
</template>

<script setup>
import { onMounted, ref } from "vue";
import { getFlowersData } from "../api";
import { useRouter } from "vue-router";

const flowersData = ref("");

const param = { Id: 0, Type: 0 };
onMounted(async () => {
  await getFlowersData(param).then((res) => {
    flowersData.value = res.data;
  });
});

const router = useRouter();
const toFlowerDetail = ({ id, type }) => {
  router.push({ path: "/detail", query: { id, type } });
};
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

.flower-item {
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
