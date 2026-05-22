import styles from './ButtonMore.module.scss'

export const ButtonMore = () => {
    return (
        <div className={styles.container}>
            <div className={styles.line}></div>
            <button className={styles.button}>
                PLN/JPY: about ↑
            </button>
        </div>
    );
}