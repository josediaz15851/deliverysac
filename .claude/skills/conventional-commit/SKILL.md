---
name: conventional-commit
description: Formato estándar tipo(scope): descripción imperativa para commits claros y navegables.
---

# Conventional Commit

Formato simple y consistente para todos los commits en DeliverySac.

## Formato obligatorio

```
tipo(scope): descripción en imperativo
```

**Sin más.** Punto. No necesita body ni footer en commits simples.

## Tipos

- **feat:** Nueva funcionalidad
- **fix:** Corrección de bug
- **docs:** Documentación (PRD, README, comentarios)
- **test:** Tests nuevos o modificados
- **refactor:** Cambio de código sin alterar funcionamiento
- **perf:** Mejora de rendimiento
- **style:** Formato (espacios, comas, etc.) — no afecta lógica
- **chore:** Config, deps, build — no toca código de producción
- **ci:** Cambios en CI/CD

## Scope (obligatorio para feat/fix)

Área afectada en DeliverySac:
- **api:** Backend (.NET, EF Core)
- **web:** Frontend (Angular)
- **db:** Base de datos, migraciones
- **auth:** Autenticación, roles
- **delivery:** Lógica de pedidos y estado
- **offline:** Sincronización offline
- **ui:** Interfaz visual
- **prd:** Requerimientos (PRD, AC, RNF)

## Descripción

- Imperativo: "agregar", "rechazar", "aclarar" — NO "agregué", "rechazado"
- Minúscula al inicio
- SIN punto final
- <= 50 caracteres
- Describe QUÉ hace, no CÓMO

## Ejemplos ✅

```
feat(auth): agregar validación de email en el registro
fix(delivery): rechazar pedidos sin líneas con HTTP 400
docs(prd): aclarar máquina de estados del pedido
test(api): validar que solo PENDIENTE permite edición
refactor(web): simplificar componente de listado
perf(db): agregar índice en tabla de asignaciones
style: alinear indentación en AuthController
chore: actualizar versión de Angular
ci: agregar eslint en pre-commit
```

## Ejemplos ❌

```
Update stuff                         ← sin tipo, vago
feat: agregar cosa que necesito     ← > 50 chars
Fix(AUTH): MAYÚSCULA               ← mayúscula
fix: agregue validacion.            ← punto final, "agregue" no imperativo
docs: actualizar PRD. (cambios)     ← sin scope para docs de código
```

## Reglas duras

1. **Siempre type(scope):** excepto docs simples tipo `docs: actualizar README`
2. **Imperativo:** "fix", "add", "remove", "update", "clarify", "validate"
3. **No abstracciones mentales:** describe el cambio visible, no la intención
4. **Duda:** mejor "chore" que inventar tipo

## Si necesita body/footer

Separás con línea en blanco:

```
feat(delivery): permitir reasignación de pedidos

El administrador puede reasignar un pedido ASIGNADO a otro repartidor.
La asignación anterior se invalida automáticamente.

Co-Authored-By: Claude Haiku 4.5 <noreply@anthropic.com>
```

Pero el 95% de los commits es solo la línea de type(scope).
