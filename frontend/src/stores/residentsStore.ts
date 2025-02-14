import { type Resident } from "@/models/resident";
import { ref } from "vue";
import { defineStore } from "pinia";
import useApi, { useApiRawRequest } from "@/models/api";

export const useResidentsStore = defineStore('residentsStore', () => {
    const apiGetResidents = useApi<Resident[]>('residents');
    const residents = ref<Resident[]>([]);
    let allResidents: Resident[] = [];

    const loadResidents = async () => {
        await apiGetResidents.request();

        if (apiGetResidents.response.value) {
            return apiGetResidents.response.value;
        }
        return [];
    };

    const load = async () => {
        allResidents = await loadResidents();
        residents.value = allResidents;
    };
    const getResidentById = (id: Number) => {
        return allResidents.find((resident) => resident.id === id);
    };


    const addResident = async (resident: Resident) => {
        const apiAddResident = useApi<Resident>('residents', {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(resident),
        });

        await apiAddResident.request();
        if (apiAddResident.response.value) {
            load();
        }
    };
    const updateResident = async (resident: Resident) => {
        const apiUpdateResident = useApi<Resident>('residents/' + resident.id, {
            method: 'PUT',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(resident),
        });

        await apiUpdateResident.request();
        if (apiUpdateResident.response.value) {
            load();
        }
    };


    const deleteResident = async (resident: Resident) => {
        const deleteResidentRequest = useApiRawRequest(`residents/${resident.id}`, {
            method: 'DELETE',
        });

        const res = await deleteResidentRequest();

        if (res.status === 204) {
            let id = residents.value.indexOf(resident);

            if (id !== -1) {
                residents.value.splice(id, 1);
            }

            id = residents.value.indexOf(resident);

            if (id !== -1) {
                residents.value.splice(id, 1);
            }
        }
    };

    return { residents, load, getResidentById, addResident, updateResident, deleteResident };
});