import { createRouter, createWebHistory } from "vue-router";
import HomePage from "../views/HomePage.vue";
import BirthdayFlower from "../views/BirthdayFlower.vue";
import FlowerDetail from "../views/FlowerDetail.vue";
import FlowerPay from "../views/FlowerPay.vue";
import FriendFlower from "../views/FriendFlower.vue";
import LoveFlower from "../views/LoveFlower.vue";
import PersonCenter from "../views/PersonCenter.vue";
import WeddingFlower from "../views/WeddingFlower.vue";

const routes = [
  { path: "/", component: HomePage },
  { path: "/birthday", component: BirthdayFlower },
  { path: "/detail", component: FlowerDetail },
  { path: "/pay", component: FlowerPay },
  { path: "/friend", component: FriendFlower },
  { path: "/love", component: LoveFlower },
  { path: "/personcenter", component: PersonCenter },
  { path: "/wedding", component: WeddingFlower },
];

const router = createRouter({
  routes,
  history: createWebHistory(),
});

export default router;
