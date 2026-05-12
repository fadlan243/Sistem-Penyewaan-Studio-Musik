# Sistem Penyewaan Studio Musik - Black Rock Studio

## UCP 2: SQL Injection Demo

### Apa itu SQL Injection?
SQL Injection adalah teknik serangan yang menyisipkan kode SQL jahat melalui input user untuk memanipulasi query database.

---

### Form yang Rentan
**FormLoginRentan** dibuat khusus untuk mendemonstrasikan celah keamanan SQL Injection.

---

### Skenario SQL Injection

#### Langkah-langkah Menyerang:

1. Buka aplikasi
2. Pilih menu **"SQL Injection Demo"** (button di FormDashboard)
3. Pada form login, masukkan data berikut:

| Field | Nilai |
|-------|-------|
| **Username** | `admin' OR '1'='1' --` |
| **Password** | `(isi apa saja, misal: abc123)` |

4. Klik tombol **"🔓 Login (Rentan)"**

#### Hasil yang Diharapkan:
✅ **Login BERHASIL** meskipun password salah!

#### Query yang Dijalankan:
```sql
SELECT * FROM users WHERE Username = 'admin' OR '1'='1' --' AND Password = 'abc123'