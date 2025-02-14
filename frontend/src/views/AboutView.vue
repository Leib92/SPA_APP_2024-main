<template>
    <EventList :title="title" />
    <ResidentList :title="title" />
</template>

<script setup lang="ts">
    import EventList from "@/components/EventList.vue";
    import ResidentList from "@/components/ResidentList.vue";
  import {defineProps} from "vue";
  
  defineProps<{ title: String}>();
</script>
