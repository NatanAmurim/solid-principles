# 🚀 Git Rebase (atualizar minha branch)

git checkout minha-branch
git fetch origin
git rebase origin/main


## 🧠 Git Rebase Interativo
git rebase -i HEAD~3

Comandos úteis:
pick: manter
reword: mudar mensagem
squash: juntar com o anterior
drop: remover o commit

## 🧽 Desfazer rebase
git rebase --abort

## 💥 Resolver conflitos no rebase
git status
git add .
git rebase --continue

# Merge vs Rebase
Use merge para colaboração, rebase para organização.
O rebase serve também para alterar históricos, fazer squase de commits, organizar antes de subir.
O merge vai juntar dois trabalhos distintos, criando um ponto de encontro.

