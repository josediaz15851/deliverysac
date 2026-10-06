---
name: conventional-commit
description: Guía para escribir commits siguiendo Conventional Commits (feat, fix, docs, refactor, test, chore, style, perf, ci). Se usa para mantener historial limpio y automatizar versionado.
---

# Conventional Commit

Estandarizá los commits siguiendo Conventional Commits. El formato permite:
- Historial legible y navegable
- Automatización de CHANGELOG
- Versionado semántico (SemVer)

## Formato obligatorio

```
<type>(<scope>): <subject>

<body>

<footer>
```

### **type** (obligatorio)

- **feat:** Nueva funcionalidad (MINOR en SemVer)
- **fix:** Corrección de bug (PATCH en SemVer)
- **docs:** Cambios en documentación
- **test:** Agregar o modificar tests
- **refactor:** Cambio de código sin alterar funcionalidad
- **perf:** Mejora de rendimiento
- **style:** Cambios de formato (espacios, comas, etc.) — no afectan funcionamiento
- **chore:** Cambios en build, deps, config — no afectan código de producción
- **ci:** Cambios en CI/CD

### **scope** (opcional pero recomendado para feat/fix)

Área del código afectada. En DeliverySac:
- **api:** Backend (.NET / EF Core)
- **web:** Frontend (Angular)
- **db:** Base de datos, migraciones
- **auth:** Autenticación y roles
- **delivery:** Lógica de pedidos y estado
- **offline:** Sincronización offline
- **ui:** Interfaz (solo cambios visuales)

### **subject** (obligatorio)

- Máximo 50 caracteres
- Modo imperativo: "add", "remove", "fix", NO "added", "removed", "fixed"
- Sin punto final
- Minúscula al inicio

### **body** (opcional pero recomendado para cambios no triviales)

- Explicá el QUÉ y el POR QUÉ, no el CÓMO
- Líneas <= 72 caracteres
- Separá del subject con línea en blanco

### **footer** (opcional)

Usa para referenciar issues o breaking changes:
- `Closes #123` — cierra un issue
- `BREAKING CHANGE: descripción` — cambio que rompe compatibilidad
- `Co-Authored-By: Name <email>` — coautoría

## Ejemplos en DeliverySac

### ✅ Bueno: feat con scope

```
feat(delivery): permitir cambio de estado de pedido a EN_RUTA

El repartidor ahora puede marcar un pedido como EN_RUTA desde su celular.
La transición valida que el pedido esté en estado ASIGNADO y registra
automáticamente la hora y el usuario.

Closes #45
```

### ✅ Bueno: fix

```
fix(api): rechazar edición de pedidos no-PENDIENTE con HTTP 400

Previously editando un pedido ASIGNADO o EN_RUTA alteraba la trazabilidad.
Ahora valida en backend que solo pedidos PENDIENTE pueden ser editados.

Closes #67
```

### ✅ Bueno: docs simple

```
docs: actualizar README con instrucciones de setup
```

### ❌ Malo

```
Update stuff                          ← vago, no tiene tipo
fix: fixed the thing                 ← "fixed" no es imperativo
feat: esto es muy largo y no dice nada clara en un renglón ← > 50 chars
FEAT(DELIVERY): MAYUSCULA            ← mayúscula
fix: agregue validacion.              ← punto final, "agregue" no imperativo
```

## Reglas para DeliverySac

1. **Commits no-triviales:** siempre incluir scope
2. **Cambios en RF/RNF/AC:** usar `docs(prd):` con referencia a qué cambió
3. **Migraciones de BD:** usar `feat(db):` o `fix(db):`
4. **Tests:** `test(scope):` si es lógica nueva o `test: ...` si es bug
5. **Duda al escribir:** mejor "chore" que inventar tipo
6. **Co-autoría:** siempre incluir línea `Co-Authored-By:` si trabajaste en equipo

## Cómo verificar tu commit

Antes de `git push`:

1. ¿El type es uno de: feat, fix, docs, test, refactor, perf, style, chore, ci?
2. ¿El scope (si existe) es claro y no muy largo?
3. ¿El subject es imperativo y <= 50 caracteres?
4. ¿El body explica el POR QUÉ, no el CÓMO?
5. ¿Hay referencias a issues cerrados (Closes #X)?

Si respondés sí a todo → listo para pushear.
