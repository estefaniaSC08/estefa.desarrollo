import streamlit as st
from sympy import symbols, limit, diff, S, latex, Rational, simplify, solve
import pandas as pd

# Configuración de la página
st.set_page_config(page_title="MathCoach: Experto en Funciones", layout="wide")

st.title("🎓 MathCoach: Taller Interactivo de Cálculo")
st.markdown("""
Bienvenido a tu tutor personal. Aquí no solo resolvemos ejercicios, 
**aprendemos a pensar** el proceso matemático.
---
""")

# Barra lateral para navegación
menu = st.sidebar.selectbox("Selecciona una unidad:", ["Límites", "Análisis de Funciones", "Derivadas"])

x = symbols('x')

if menu == "Límites":
    st.header("🔍 Unidad 1: Límites y Continuidad")
    st.write("El límite es el valor al que se acerca una función cuando la variable se aproxima a un punto.")
    
    col1, col2 = st.columns(2)
    with col1:
        func_input = st.text_input("Ingresa la función f(x):", " (x**2 - 4) / (x - 2) ")
        punto_a = st.number_input("Punto al que tiende x (a):", value=2)
    
    if st.button("Resolver Paso a Paso"):
        try:
            f = simplify(func_input)
            res = limit(f, x, punto_a)
            
            st.subheader("Resolución Pedagógica:")
            st.write(f"**1. Evaluación Directa:** Intentamos sustituir $x = {punto_a}$ en $f(x)$.")
            
            # Mostrar la función en LaTeX
            st.latex(f"\\lim_{{x \\to {punto_a}}} {latex(f)}")
            
            st.write("**2. Análisis de Indeterminación:**")
            numerador = simplify(func_input).as_numer_denom()[0]
            denominador = simplify(func_input).as_numer_denom()[1]
            
            val_num = numerador.subs(x, punto_a)
            val_den = denominador.subs(x, punto_a)
            
            if val_num == 0 and val_den == 0:
                st.warning("¡Indeterminación detected! Tipo $0/0$. Necesitamos factorizar o simplificar.")
                st.write("**3. Simplificación:**")
                st.latex(f"f(x) = {latex(simplify(f))}")
            
            st.success(f"**Resultado Final:** El límite es ${latex(res)}$")
            
        except Exception as e:
            st.error(f"Error en la expresión: {e}")

elif menu == "Análisis de Funciones":
    st.header("📈 Unidad 2: Anatomía de una Función")
    
    func_ana = st.text_input("Introduce la función para analizar (ej. 1/(x-1)):", "x**2 / (x-1)")
    
    if st.button("Analizar"):
        f_ana = simplify(func_ana)
        
        # 1. Dominio (Simplificado para funciones racionales)
        den = f_ana.as_numer_denom()[1]
        puntos_criticos = solve(den, x)
        
        st.write("### 1. Dominio")
        if not puntos_criticos:
            st.latex(r"D_f = \mathbb{R}")
        else:
            st.write(f"La función no existe donde el denominador es cero. Resolviendo $denominador = 0$:")
            st.latex(f"x = {puntos_criticos}")
            st.latex(rf"D_f = \mathbb{{R}} \setminus \{{ {','.join(map(str, puntos_criticos))} \}}")

        # 2. Asíntotas Verticales
        st.write("### 2. Asíntotas Verticales")
        for p in puntos_criticos:
            lim_izq = limit(f_ana, x, p, dir='-')
            lim_der = limit(f_ana, x, p, dir='+')
            st.write(f"En $x = {p}$:")
            st.latex(rf"\lim_{{x \to {p}^-}} f(x) = {latex(lim_izq)}, \quad \lim_{{x \to {p}^+}} f(x) = {latex(lim_der)}")

        # Gráfico (Placeholder pedagógico)
        st.info("💡 Consejo: Observa cómo se comporta la función cerca de los valores excluidos del dominio.")

elif menu == "Derivadas":
    st.header("⚡ Unidad 3: La Razón de Cambio")
    f_der = st.text_input("Función a derivar:", "3*x**3 + 2*x**2 - 5")
    
    if st.button("Calcular Derivada"):
        expr = simplify(f_der)
        derivada = diff(expr, x)
        
        st.write("**Proceso:** Aplicamos las reglas de derivación (potencia, suma, etc.)")
        st.latex(f"\\frac{{d}}{{dx}} ({latex(expr)}) = {latex(derivada)}")
        
        st.write("**Interpretación:** Esta expresión representa la pendiente de la recta tangente en cualquier punto $x$.")