import React, { useEffect, useState } from 'react';
import { Person } from '../../store/sagas/person/types';
import api from '../api';

const useFetch = <T>(url: string, options = {}) => {
    const [data, setData] = useState<T[]>([]);
    const [error, setError] = useState(null);
    const [isLoading, setLoading] = useState(false);

    useEffect(() => {
        const fetchData = async () => {
            try {
                setLoading(true);
                const res = await api.get('person');
                setLoading(false);
                setData(res);
            } catch (error) {
                setError(error);
                setLoading(false);
            }
        };
        fetchData();
    }, []);

    return {
        data,
        error,
        isLoading
    };
};

export default useFetch;