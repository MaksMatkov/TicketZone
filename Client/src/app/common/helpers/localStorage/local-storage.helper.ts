export class LocalStorageHelper {
    public static Get<T>(key: string): T | null {
        if(!key) {
            return null;
        }

        const res = localStorage.getItem(key);

        if(res) {
            return JSON.parse(res) as T;
        }

        return null;
    }

    public static Remove(key: string): void {
        if(!key) {
            return;
        }

        localStorage.removeItem(key);
    }

    public static Set<T>(key: string, data: T) {
        if(!key) {
            return;
        }

        const value = JSON.stringify(data);
        localStorage.setItem(key, value);
    }

    public static Has(key: string): boolean {
        const res = localStorage.getItem(key);
        return !!res;
    }
}