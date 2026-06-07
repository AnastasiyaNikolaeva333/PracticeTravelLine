import { render, screen } from '@testing-library/react';
import { Header } from '../components/CurrencyTransfer/Header/Header';
import { TableTranslation } from '../components/CurrencyTransfer/TableTranslation/TableTranslation';

describe('CurrencyTransfer Component', () => {
    const fromHeader = {
        value: 1,
        name: "Polish zloty is"
    }
    const toHeader = {
        value: 0.99,
        name: "Japanese yen"
    }

    const fromTableTranslation = {
        value: 1,
        code: "PLN"
    }
    const toTableTranslation = {
        value: 0.99,
        code: "JPY"
    }

    it('отображает текс о курсе валют на текущий момент', () => {
        render(<Header from={fromHeader} to={toHeader} date={new Date()} />);

        expect(screen.getByText(/1 Polish zloty is/)).toBeTruthy();
        expect(screen.getByText(/0\.99 Japanese yen/)).toBeTruthy();

    });

    it('отображает две строки', () => {
        const { container } = render(<TableTranslation from={fromTableTranslation} to={toTableTranslation} />);

        const rows = container.querySelectorAll('[class*="rowTable"]');
        expect(rows).toHaveLength(2);
    });

    it('отображает PLN и JPY', () => {
        render(<TableTranslation from={fromTableTranslation} to={toTableTranslation} />);

        expect(screen.getByText('PLN')).toBeInTheDocument();
        expect(screen.getByText('JPY')).toBeInTheDocument();
    });

    it('отображает значения 1 и 0,99', () => {
        render(<TableTranslation from={fromTableTranslation} to={toTableTranslation} />);

        expect(screen.getByText('1')).toBeInTheDocument();
        expect(screen.getByText('0.99')).toBeInTheDocument();
    });

    it('отображает две кнопки', () => {
        render(<TableTranslation from={fromTableTranslation} to={toTableTranslation} />);

        const buttons = screen.getAllByRole('button');
        expect(buttons).toHaveLength(2);
    });
});