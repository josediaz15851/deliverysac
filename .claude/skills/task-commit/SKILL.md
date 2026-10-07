---
name: task-commit
description: Verifica build de frontend y backend, luego commitea tarea completada usando conventional-commit. Se usa cuando terminas una subtarea del plan.
---

# Task Commit

Cuando termines una subtarea que compila:

1. **Verifica que compila (backend)**
   ```
   cd API
   dotnet build
   dotnet test
   ```
   Si falla, arreglá primero. NO continúes si hay errores.

2. **Verifica que compila (frontend)**
   ```
   cd web
   npm run build
   ```
   Si falla, arreglá primero.

3. **Usa conventional-commit para el mensaje**
   
   Formato: `tipo(scope): descripción`
   - **tipo:** feat, fix, docs, test, refactor (del skill conventional-commit)
   - **scope:** api, web, auth, delivery, db, etc.
   - **descripción:** imperativo, minúscula, sin punto
   
   Ejemplos:
   - `feat(api): crear modelo usuario + dbcontext`
   - `feat(web): crear authservice`
   - `test(api): validar máquina de estados`

4. **Stagea y commitea**
   ```
   git add <archivos>
   git commit -m "tipo(scope): descripción"
   git push origin main
   ```

5. **Solo archivos de la subtarea** (no bin/, obj/, dist/, node_modules/)

Una subtarea = un commit. Limpio, pequeño, compilable.
