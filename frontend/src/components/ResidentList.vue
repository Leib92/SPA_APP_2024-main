<template>
    <div class="about">
        <h1>Residentlist</h1>
        <div class="residentlist">
            <DataTable :value="residents" v-if="residents.length > 0 ">
                <Column field="id" header="Elaniku id" style="color: black; " />
                <Column field="name" header="Elaniku Nimi" style="color: black; " />
                <Column field="description" header="Kirjeldus" style="color: black; " />
                <Column field="job" header="Töö" style="color: black;" />
                <Column field="birthdate" header="Sünnipäev" style="color: black;" />
            </DataTable>
            <div v-else>Sündmused puuduvad</div>
        </div>
    </div>
</template>


<script setup lang="ts">
import { type Resident } from '@/models/resident';
import { useResidentsStore } from "@/stores/residentsStore";
import { storeToRefs } from "pinia";
import { defineProps, onMounted, watch, ref  } from "vue";
import { useRoute } from "vue-router";

const route = useRoute();

watch(route, (to, from) => {
  if (to.path !== from.path || to.query !== from.query) {
    residentsStore.load();
  }
}, { deep: true });

defineProps<{ title: String }>();
const residentsStore = useResidentsStore();
const { residents } = storeToRefs(residentsStore);

onMounted(async () => {
  residentsStore.load();
});
</script>
<style>
</style>